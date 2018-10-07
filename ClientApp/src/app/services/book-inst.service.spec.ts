import { TestBed, inject } from '@angular/core/testing';

import { BookInstService } from './book-inst.service';

describe('BookInstService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BookInstService]
    });
  });

  it('should be created', inject([BookInstService], (service: BookInstService) => {
    expect(service).toBeTruthy();
  }));
});
