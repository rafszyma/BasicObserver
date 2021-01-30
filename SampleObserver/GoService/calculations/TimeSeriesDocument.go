package calculations

import (
	"go.mongodb.org/mongo-driver/bson/primitive"
)

type TimeSeriesDocu struct {
	ID primitive.ObjectID `bson:"_id" json:"id,omitempty"`
	Time int64 `bson:"T" json:"T"`
	Value int64 `bson:"V" json:"V"`
}
