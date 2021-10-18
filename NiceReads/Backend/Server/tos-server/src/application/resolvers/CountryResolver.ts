import { Arg, FieldResolver, Query, Resolver, Root } from 'type-graphql';
import container from '../../configuration/ContainerConfig';
import { ICommandDispatcher } from '../../cqrs/dispatchers/commands/ICommandDispatcher';
import { IQueryDispatcher } from '../../cqrs/dispatchers/queries/IQueryDispatcher';
import { Types } from '../../types';
import { GetCountryByNameAsyncQuery } from '../cqrs/queries/countries/GetCountryByNameAsyncQuery';
import { GetStatesByCountryIdAsyncQuery } from '../cqrs/queries/states/GetStatesByCountryIdAsynQuery';
import { Country } from '../models/Country';
import { State } from '../models/State';
import { CountryDto } from '../schemas/CountryDto';

@Resolver(CountryDto)
export class CountryResolver {
    private readonly commandDispatcher: ICommandDispatcher;
    private readonly queryDispatcher: IQueryDispatcher;

    constructor() {
            this.commandDispatcher = container.get<ICommandDispatcher>(Types.COMMAND_DISPATCHER);
            this.queryDispatcher = container.get<IQueryDispatcher>(Types.QUERY_DISPATCHER);
    }

    @Query(returns => [CountryDto], { nullable: true})
    async countriesByName(@Arg('name') name: string): Promise<Country[]> {
        return await this.queryDispatcher.executeAsync(new GetCountryByNameAsyncQuery(name));
    }

    @FieldResolver()
    async states(@Root() country: Country): Promise<State[] | undefined> {
        return await this.queryDispatcher.executeAsync(new GetStatesByCountryIdAsyncQuery(country.id));
    }
}