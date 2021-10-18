import { Uuid } from '../../../common/uuid';
import { State } from '../../models/State';
import { IRepository } from '../../../data/repository';

export interface IStateRepository extends IRepository<State, Uuid> {
    findByCountryIdAsync(countryId: Uuid): Promise<State[]>;
    findByNameAsync(name: string): Promise<State[]>;
}