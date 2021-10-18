import { Field, ID, ObjectType } from 'type-graphql';
import { CityDto } from './CityDto';
import { CountryDto } from './CountryDto';

@ObjectType('State')
export class StateDto {
    @Field(type => ID)
    id: string;
    @Field()
    name: string;
    @Field(type => CountryDto)
    country: CountryDto;
    @Field(type => [CityDto])
    cities: CityDto[];
}