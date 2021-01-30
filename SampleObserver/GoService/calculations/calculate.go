package calculations

import (
	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
	"golang.org/x/net/context"
	"google.golang.org/grpc/metadata"
	_ "google.golang.org/protobuf/proto"
	"log"
)

type Server struct {
	client *mongo.Client
}

func NewServer(client *mongo.Client) *Server {
	s := new(Server)
	s.client = client
	return s
}

func (s *Server) CalculateTimePeriod(ctx context.Context, request *CalculateRequest) (*CalculateResponse, error) {
	md, _ := metadata.FromIncomingContext(ctx)
	tenant := md.Get("tenant")
	log.Printf("Request for tenant: %s values from: %d to: %d", tenant, request.From, request.To)
	filter := bson.M{"$and": []bson.D{
		{{"T", bson.D{{"$gte", request.From}}}},
		{{"T", bson.D{{"$lte", request.To}}}},
	},
	}
	cursor, _ := s.client.Database(tenant[0]).Collection("TimeSeries").Find(ctx, filter)
	defer cursor.Close(ctx)
	response := &CalculateResponse{Sum: 0}
	counter := 0.0
	if cursor.RemainingBatchLength() == 0 {
		response.Average = 0
		return response, nil
	}
	for cursor.Next(ctx) {
		var record TimeSeries
		cursor.Decode(&record)
		response.Sum += record.Value
		counter++
	}

	response.Average = response.Sum / counter
	return response, nil
}
