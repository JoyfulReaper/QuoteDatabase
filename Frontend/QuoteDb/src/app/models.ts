export enum QuoteType {
    Unknown = 0,
    Book = 1,
    Movie = 2,
    Person = 3,
    Song = 4,
}

export class Quote {
    quoteId?: number;
    text: string;
    authorDisplay: string;
    quoteType: QuoteType;
}

export class Song extends Quote {
    title: string;
    album?: string;
    artist?: string;
    track?: number;
}

export class SongRequest {
    text: string;
    title: string;
    album?: string;
    artist?: string;
    track?: number;
}


export class Movie extends Quote {
    title: string;
    characterName: string;
    actorName: string;
}

export class MovieRequest {
    text: string;
    title: string;
    characterName: string;
    actorName: string;
}

export class Book extends Quote{
    title: string;
    author: string;
    chapter?: string;
    page?: number;
}

export class BookRequest {
    text: string;
    title: string;
    author: string;
    chapter?: string;
    page?: number;
}

export class Person extends Quote {
    firstName: string;
    lastName: string;
}

export class PersonRequest {
    text: string;
    firstName: string;
    lastName: string;
}