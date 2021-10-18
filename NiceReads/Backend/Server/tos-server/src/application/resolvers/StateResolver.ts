import { Arg, FieldResolver, Query, Resolver, Root } from 'type-graphql';
import container from '../../configuration/ContainerConfig';
import { ICommandDispatcher } from '../../cqrs/dispatchers/commands/ICommandDispatcher';
import { IQueryDispatcher } from '../../cqrs/dispatchers/queries/IQueryDispatcher';
import { Types } from '../../types';
import { GetCitiesByStateIdAsyncQuery } from '../cqrs/queries/cities/GetCitiesByStateIdAsyncQuery';
import { GetStatesByNameAsyncQuery } from '../cqrs/queries/states/GetStatesByNameAsyncQuery';
import { City } from '../models/City';
import { State } from '../models/State';
import { CityDto } from '../schemas/CityDto';
import { StateDto } from '../schemas/StateDto';

@Resolver(StateDto)
export class StateResolver {
    private readonly commandDispatcher: ICommandDispatcher;
    private readonly queryDispatcher: IQueryDispatcher;

    constructor() {
            this.commandDispatcher = container.get<ICommandDispatcher>(Types.COMMAND_DISPATCHER);
            this.queryDispatcher = container.get<IQueryDispatcher>(Types.QUERY_DISPATCHER);
    }

    @Query(returns => [StateDto], { nullable: true})
    async statesByName(@Arg('name') name: string): Promise<State[]> {
        return await this.queryDispatcher.executeAsync(new GetStatesByNameAsyncQuery(name));
    }

    @FieldResolver(returns => [CityDto])
    async cities(@Root() state: State): Promise<City[]> {
        return await this.queryDispatcher.executeAsync(new GetCitiesByStateIdAsyncQuery(state.id));
    }
}