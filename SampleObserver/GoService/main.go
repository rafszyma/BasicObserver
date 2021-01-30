package main

import (
	"github.com/rafszyma/BasicObserver/tree/main/SampleObserver/GoService/calculations"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
	"golang.org/x/net/context"
	"google.golang.org/grpc"
	"log"
	"net"
	"os"
	"time"
)

func main() {
	lis, err := net.Listen("tcp", ":9000")
	if err != nil {
		log.Fatalf("Failed to listen on port 9000: %v", err)
	}

	ctx, _ := context.WithTimeout(context.Background(), 10*time.Second)
	clientOptions := options.Client().ApplyURI(os.Getenv("MongoUrl"))
	client, _ := mongo.Connect(ctx, clientOptions)

	server := calculations.NewServer(client)
	grpcServer := grpc.NewServer()

	calculations.RegisterCalculateServer(grpcServer, server)

	if err := grpcServer.Serve(lis); err != nil {
		log.Fatalf("Failed to serve gRPC server")
	}
}
