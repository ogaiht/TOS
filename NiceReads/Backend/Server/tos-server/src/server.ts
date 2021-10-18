import 'reflect-metadata';
import express from 'express';
import { ApolloServer } from 'apollo-server-express';
import cors from 'cors';
import { Context } from 'apollo-server-core';
import { buildSchema } from 'type-graphql'
import { ProjectResolver } from './application/resolvers/project-resolver';
import { initData } from './data/data';
import { TaskResolver } from './application/resolvers/task-resolver';
import { CountryResolver } from './application/resolvers/CountryResolver';
import { StateResolver } from './application/resolvers/StateResolver';
import { CityResolver } from './application/resolvers/CityResolver';

async function main() {

    //const id = container.id;
    initData();

    const app = express();

    const schema = await buildSchema({
        resolvers: [ProjectResolver, TaskResolver, CityResolver, CountryResolver, StateResolver],
        emitSchemaFile: true
    });
    const server: ApolloServer = new ApolloServer({
        context: (context: Context) => {

        },
        schema,
        introspection: true,
        //playground: true
    });

    app.use(cors());

    await server.start();

    server.applyMiddleware({ app, path: '/graphql' });

    app.listen({ port: 8000 }, () => {
        console.log('Apollo Server runnint on ');
    });
}

main();