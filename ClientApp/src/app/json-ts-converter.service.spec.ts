import { BookInstance } from './pocos/bookInstance';
import { TestBed, inject } from '@angular/core/testing';

import { JsonTsConverterService } from './json-ts-converter.service';

describe('JsonTsConverterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [JsonTsConverterService]
    });
  });

  it('should be created', inject([JsonTsConverterService], (service: JsonTsConverterService) => {
    expect(service).toBeTruthy();

  }));

  it('should return an object when convert is called', inject([JsonTsConverterService], (service: JsonTsConverterService) => {
    const mockBookInstanceJson = {
      'id': 2011,
      'definitionId': 0,
      'numberInStock': 0,
      'pageNumber': 0,
      'edition': 0,
      'bookName': 'Algının Kapıları',
      'writerName': 'Aldous Huxley',
      'genres': [],
      'price': 66,
      'languageName': '',
      'languageId': 2,
      'publisherName': '',
      'publisherId': 4,
      'translatorId': 1,
      'translatorName': '',
      'photoPath': 'uploadFolder/b0deb240-fad0-4bfd-a69d-e9c10cca376f.jpg',
      'photoFileName': ''
    };

    const convertResult = service.convert<BookInstance>(mockBookInstanceJson, BookInstance);


    expect(convertResult).toBeDefined();
    expect(convertResult.id).toBeGreaterThan(0);
  }));


});
