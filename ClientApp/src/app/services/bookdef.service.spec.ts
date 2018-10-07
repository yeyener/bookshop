import { TestBed, inject } from '@angular/core/testing';

import { BookdefService } from './bookdef.service';

describe('BookdefService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BookdefService]
    });
  });

  it('should be created', inject([BookdefService], (service: BookdefService) => {
    expect(service).toBeTruthy();
  }));
});
