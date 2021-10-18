import { Arg, FieldResolver, Query, Resolver, Root } from 'type-graphql';
import container from '../../configuration/ContainerConfig';
import { ICommandDispatcher } from '../../cqrs/dispatchers/commands/ICommandDispatcher';
import { IQueryDispatcher } from '../../cqrs/dispatchers/queries/IQueryDispatcher';
import { Types } from '../../types';
import { GetCitiesByNameAsyncQuery } from '../cqrs/queries/cities/GetCitiesByNameAsyncQuery';
import { GetStateByIdAsyncQuery } from '../cqrs/queries/states/GetStateByIdAsyncQuery';
import { City } from '../models/City';
import { State } from '../models/State';
import { CityDto } from '../schemas/CityDto';
import { StateDto } from '../schemas/StateDto';

@Resolver(CityDto)
export class CityResolver {
    private readonly commandDispatcher: ICommandDispatcher;
    private readonly queryDispatcher: IQueryDispatcher;

    constructor() {
            this.commandDispatcher = container.get<ICommandDispatcher>(Types.COMMAND_DISPATCHER);
            this.queryDispatcher = container.get<IQueryDispatcher>(Types.QUERY_DISPATCHER);
    }

    @Query(returns => [CityDto], { nullable: true})
    async citiesByName(@Arg('name') name: string): Promise<City[]> {
        return await this.queryDispatcher.executeAsync(new GetCitiesByNameAsyncQuery(name));
    }

    @FieldResolver(returns => StateDto)
    async state(@Root() city: City): Promise<State | undefined> {
        return await this.queryDispatcher.executeAsync(new GetStateByIdAsyncQuery(city.stateId));
    }
}