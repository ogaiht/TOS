import { Field, InputType } from 'type-graphql';

@InputType({ description: 'New Project'})
export class AddProjectInput {

    @Field()
    name: string;
    @Field(type => [AddTaskInput])
    tasks?: AddTaskInput[]
}

@InputType({ description: 'New Task'})
export class AddTaskInput  {
    @Field()
    title: string;
}