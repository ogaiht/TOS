import { Field, ObjectType } from 'type-graphql';
import { Project } from './project';

@ObjectType()
export class Task {
    @Field()
    id: string;
    @Field()
    title: string;
    @Field(type => Project)
    project: Project;
    @Field()
    completed: boolean;
}