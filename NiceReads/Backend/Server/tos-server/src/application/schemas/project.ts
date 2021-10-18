import { Field, ID, ObjectType } from 'type-graphql';
import { Task } from './task';

@ObjectType()
export class Project {
    @Field(type => ID)
    id: string;
    @Field()
    name: string;
    @Field(type => [Task])
    tasks: Task[];
}