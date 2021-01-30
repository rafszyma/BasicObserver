package main

import (
	"github.com/rafszyma/BasicObserver/tree/main/SampleObserver/GoService/calculations"
	"google.golang.org/grpc"
	"log"
	"net"
)

func main() {
	lis, err := net.Listen("tcp", ":9000")
	if err != nil {
		log.Fatalf("Failed to listen on port 9000: %v", err)
	}

	server := calculations.Server{}
	grpcServer := grpc.NewServer()

	calculations.RegisterCalculateServer(grpcServer, &server)

	if err := grpcServer.Serve(lis); err != nil {
		log.Fatalf("Failed to serve gRPC server")
	}
}
