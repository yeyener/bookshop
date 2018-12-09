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
});
