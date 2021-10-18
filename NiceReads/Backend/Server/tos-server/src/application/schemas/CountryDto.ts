import { Field, ID, ObjectType } from 'type-graphql';
import { StateDto } from './StateDto';

@ObjectType('Country')
export class CountryDto {
    @Field(type => ID)
    id: string;
    @Field()
    name: string;
    @Field(type => [StateDto])
    states: StateDto[]
}