package calculations

import (
	"go.mongodb.org/mongo-driver/mongo"
	"golang.org/x/net/context"
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
	s.client.
	log.Print("Calculating request")
	return &CalculateResponse{Average: 1, Sum: 2}, nil
}