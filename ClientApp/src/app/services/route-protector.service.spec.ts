import { TestBed, inject } from '@angular/core/testing';

import { RouteProtectorService } from './route-protector.service';

describe('RouteProtectorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RouteProtectorService]
    });
  });

  it('should be created', inject([RouteProtectorService], (service: RouteProtectorService) => {
    expect(service).toBeTruthy();
  }));
});
