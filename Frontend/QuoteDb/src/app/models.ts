export class Song {
    quoteId?: number;
    text: string;
    authorDisplay: string;
    title: string;
    album?: string;
    artist?: string;
    track?: number;
}

export class Quote {
    quoteId?: number;
    text: string;
    authorDisplay: string;
}

export class Movie {
    quoteId?: number;
    text: string;
    authorDisplay: string;
    title: string;
    characterName: string;
    actorName: string;
}

export class Book {
    quoteId?: number;
    text: string;
    authorDisplay: string;
    title: string;
    author: string;
    chapter?: string;
    page?: number;
}