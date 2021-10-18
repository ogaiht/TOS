import { Container } from 'inversify';
import { configApplication } from '../application/AppConfig';
import { configCqrs } from '../cqrs/CqrsConfig';
import { configDataObjects } from '../data/DataConfig';
import { Types } from '../types';

const container = new Container();

console.log('Creating container.');

container.bind(Types.CONTAINER).toConstantValue(container);

configCqrs(container);
configDataObjects(container);
configApplication(container);

export default container;