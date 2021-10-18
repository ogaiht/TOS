import { Uuid } from '../../../common/uuid';
import { City } from '../../models/City';
import { IRepository } from '../../../data/repository';

export interface ICityRepository extends IRepository<City, Uuid> {
    findByNameAsync(name: string): Promise<City[]>;
    findByStateIdAsync(statedId: Uuid): Promise<City[]>;
}