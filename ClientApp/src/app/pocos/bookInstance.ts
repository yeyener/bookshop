import { DecimalPipe } from '@angular/common';

export class BookInstance {
    writerName: string;
    bookName: string;
    definitionId: number;
    price: DecimalPipe;
    numberInStock: number;
    edition: string;
    publisherName: string;
    languageName: string;
    translatorId: number;
    // languageName: string;

}
