package calculations

import (
	"go.mongodb.org/mongo-driver/bson/primitive"
)

type TimeSeries struct {
	ID primitive.ObjectID `bson:"_id" json:"id,omitempty"`
	Time float64 `bson:"T" json:"T"`
	Value float64 `bson:"V" json:"V"`
}
