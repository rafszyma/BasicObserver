package calculations

import (
	"golang.org/x/net/context"
	_ "google.golang.org/protobuf/proto"
	"log"
)

type Server struct {

}

func (s *Server) CalculateTimePeriod(ctx context.Context, request *CalculateRequest) (*CalculateResponse, error) {
	log.Print("Calculating request")
	return &CalculateResponse{Average: 1, Sum: 2}, nil
}