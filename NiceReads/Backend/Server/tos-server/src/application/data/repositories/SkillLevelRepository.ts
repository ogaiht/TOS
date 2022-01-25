import { inject, injectable } from 'inversify';
import { constr } from '../../../common/common.types';
import { Uuid } from '../../../common/uuid';
import { Repository } from '../../../data/repository';
import { IDatabase } from '../../../database/database';
import { Types } from '../../../types';
import { SkillLevel } from '../../models/SkillLevel';
import { ISkillLevelRepository } from './ISkillLevelRepository';

@injectable()
export class SkillLevelRepository extends Repository<SkillLevel, Uuid> implements ISkillLevelRepository {
    constructor(@inject(Types.DATABASE) database: IDatabase<Uuid>) {
        super(database);
    }
    getEntityType(): constr<SkillLevel> {
        return SkillLevel;
    }
}