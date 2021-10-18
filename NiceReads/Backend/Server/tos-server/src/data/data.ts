import { City } from '../application/models/City';
import { Country } from '../application/models/Country';
import { State } from '../application/models/State';
import { Uuid } from '../common/uuid';
import container from '../configuration/ContainerConfig';
import { ICollection } from '../database/collection';
import { ICollectionItem, IDatabase } from '../database/database';
import { Types } from '../types';


export class ProjectData implements ICollectionItem<Uuid> {
    constructor(
        public name: string = '',
        public id: Uuid = Uuid.EMPTY
    ) { }
}

export class TaskData implements ICollectionItem<Uuid> {
    constructor(
        public title: string = '',
        public completed: boolean = false,
        public projectId: Uuid = Uuid.EMPTY,
        public id: Uuid = Uuid.EMPTY
    ) {}
}

export function getDatabase(): IDatabase<Uuid> {
    return container.get<IDatabase<Uuid>>(Types.DATABASE);
}

export function initData() {
    createProjectAndTasks('Become Rich', ['Come up with an idea', 'Implement it']);
    createProjectAndTasks('Enjoy life', ['Visit different places', 'Eat tasty food']);
    createCountry([{
        country: 'Brazil',
        states: [
            {
                state: 'Minas Gerais',
                cities: [
                    'Belo Horizonte',
                    'Capitólio',
                    'Contagem'
                ]
            },
            {
                state: 'São Paulo',
                cities: [
                    'São Paulo',
                    'Campinas',
                    'Bragança'
                ]
            },
            {
                state: 'Rio de Janeiro',
                cities: ['Rio de Janeiro']
            }
        ]
    },
{
    country: 'United States',
    states: [
        {
            state:'Illinois',
            cities: [
                'Chicago',
                'Oak Park',
                'Naperville'
            ]
        }
    ]
}]);
}

function createProjectAndTasks(projectName: string, tasks: string[]): void {
    const database: IDatabase<Uuid> = getDatabase();
    const projectCollection: ICollection<ProjectData, Uuid> = database.getCollection<ProjectData>(ProjectData);
    const taskCollection: ICollection<TaskData, Uuid> = database.getCollection<TaskData>(TaskData);

    const projectId: Uuid = projectCollection.add(new ProjectData(projectName));
    for (let task of tasks) {
        taskCollection.add(new TaskData(task, false, projectId));
    }
}

interface CountryData {
    country: string,
    states: StateData[]
}

interface StateData {
    state: string,
    cities: string[]
}

function createCountry(countryData: CountryData[] ): void {
    const database: IDatabase<Uuid> = getDatabase();
    for (const countryDataItem of countryData) {
        const countryId: Uuid = database.getCollection(Country).add(new Country(countryDataItem.country));
        for(const stateData of countryDataItem.states) {
            const stateId: Uuid = database.getCollection(State).add(new State(stateData.state, countryId));
            for (const city of stateData.cities) {
                database.getCollection(City).add(new City(city, stateId));
            }
        }
    }
}