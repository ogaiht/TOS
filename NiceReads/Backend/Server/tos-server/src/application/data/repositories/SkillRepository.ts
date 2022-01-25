import { inject, injectable } from 'inversify';
import { constr } from '../../../common/common.types';
import { Uuid } from '../../../common/uuid';
import { Repository } from '../../../data/repository';
import { IDatabase } from '../../../database/database';
import { Types } from '../../../types';
import { Skill } from '../../models/Skill';
import { ISkillRepository } from './ISkillRepository';

@injectable()
export class SkillRepository extends Repository<Skill, Uuid> implements ISkillRepository {
    constructor(@inject(Types.DATABASE) database: IDatabase<Uuid>) {
        super(database);
    }
    getEntityType(): constr<Skill> {
        return Skill;
    }
}