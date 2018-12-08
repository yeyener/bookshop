import { DecimalPipe } from '@angular/common';
import {JsonObject, JsonProperty} from 'json2typescript';

@JsonObject('BookInstance')
export class BookInstance {
    @JsonProperty('id', Number)
    id: number = undefined;

    @JsonProperty('writerName', String)
    writerName: string = undefined;

    @JsonProperty('bookName', String)
    bookName: string = undefined;

    @JsonProperty('definitionId', Number)
    definitionId: number = undefined;

    @JsonProperty('price', Number)
    price: number = undefined;

    @JsonProperty('numberInStock', Number)
    numberInStock: number = undefined;

    @JsonProperty('edition', Number)
    edition: number = undefined;

    @JsonProperty('publisherName', String)
    publisherName: string = undefined;

    @JsonProperty('publisherId', Number)
    publisherId: number = undefined;

    @JsonProperty('languageName', String)
    languageName: string = undefined;

    @JsonProperty('languageId', Number)
    languageId: number = undefined;

    @JsonProperty('translatorId', Number)
    translatorId: number = undefined;

    @JsonProperty('pageNumber', Number)
    pageNumber: number = undefined;

    @JsonProperty('genres', [String])
    genres: [string] = undefined;

    @JsonProperty('photoPath', String)
    photoPath: string = undefined;

    sallamasyon = 'bir metin';

    // languageName: string;

    static createEmpty() {
        const newObject = new BookInstance();
        newObject.id = -1;
        newObject.definitionId = -1;
        newObject.publisherName = '-1';
        newObject.publisherId = -1;
        newObject.languageName = '-1';
        newObject.languageId = -1;
        newObject.translatorId = null;
        newObject.price = 0;
        newObject.writerName = '';
        newObject.bookName = '';
        newObject.numberInStock = 0;
        newObject.edition = 1;
        newObject.pageNumber = 0;

        return newObject;
    }
}
