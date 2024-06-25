// This file is auto-generated by @hey-api/openapi-ts

export type Actor = {
    name?: string | null;
};

export type Movie = {
    id?: string;
    title?: string | null;
    year?: number;
    summary?: string | null;
    director?: string | null;
    genres?: Array<(string)> | null;
    actors?: Array<Actor> | null;
    posterPath?: string | null;
    rating: number | null;
};

export type GetApiMoviesResponse = Array<Movie>;

export type PostApiMoviesData = {
    requestBody: Movie;
};

export type PostApiMoviesResponse = void;

export type GetApiMoviesByIdData = {
    id: string;
};

export type GetApiMoviesByIdResponse = Movie;

export type PutApiMoviesByIdData = {
    id: string;
    requestBody: Movie;
};

export type PutApiMoviesByIdResponse = Array<Movie>;

export type DeleteApiMoviesByIdData = {
    id: string;
};

export type DeleteApiMoviesByIdResponse = void;

export type $OpenApiTs = {
    '/api/movies': {
        get: {
            res: {
                /**
                 * Success
                 */
                200: Array<Movie>;
            };
        };
        post: {
            req: PostApiMoviesData;
            res: {
                /**
                 * No Content
                 */
                204: void;
            };
        };
    };
    '/api/movies/{id}': {
        get: {
            req: GetApiMoviesByIdData;
            res: {
                /**
                 * Success
                 */
                200: Movie;
            };
        };
        put: {
            req: PutApiMoviesByIdData;
            res: {
                /**
                 * Success
                 */
                200: Array<Movie>;
            };
        };
        delete: {
            req: DeleteApiMoviesByIdData;
            res: {
                /**
                 * No Content
                 */
                204: void;
            };
        };
    };
};