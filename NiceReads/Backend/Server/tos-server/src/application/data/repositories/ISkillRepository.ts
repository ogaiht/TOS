import { Uuid } from '../../../common/uuid';
import { IRepository } from '../../../data/repository';
import { Skill } from '../../models/Skill';

export interface ISkillRepository extends IRepository<Skill, Uuid> {

}