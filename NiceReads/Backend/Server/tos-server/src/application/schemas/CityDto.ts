import { Field, ID, ObjectType } from 'type-graphql';
import { StateDto } from './StateDto';

@ObjectType('City')
export class CityDto {
    @Field(type => ID)
    id: string;
    @Field()
    name: string;
    @Field(type => StateDto)
    state: StateDto;
}