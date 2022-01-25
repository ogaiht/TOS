import { Uuid } from '../../../common/uuid';
import { IRepository } from '../../../data/repository';
import { SkillLevel } from '../../models/SkillLevel';

export interface ISkillLevelRepository extends IRepository<SkillLevel, Uuid> {

}