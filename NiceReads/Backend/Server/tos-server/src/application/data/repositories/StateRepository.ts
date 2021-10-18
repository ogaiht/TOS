import { inject, injectable } from 'inversify';
import { constr } from '../../../common/common.types';
import { Uuid } from '../../../common/uuid';
import { IDatabase } from '../../../database/database';
import { State } from '../../models/State';
import { Types } from '../../../types';
import { Repository } from '../../../data/repository';
import { IStateRepository } from './IStateRepository';

@injectable()
export class StateRepository extends Repository<State, Uuid> implements IStateRepository {

    constructor(@inject(Types.Data.DATABASE) database: IDatabase<Uuid>) {
        super(database);
    }

    protected getEntityType(): constr<State> {
        return State;
    }

    async findByCountryIdAsync(countryId: Uuid): Promise<State[]> {
        return await this.collection.findAsync((s: State) => s.countryId === countryId);
    }

    async findByNameAsync(name: string): Promise<State[]> {
        return await this.collection.findAsync((s: State) => s.name.startsWith(name));
    }
}