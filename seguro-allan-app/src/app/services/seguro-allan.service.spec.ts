import { TestBed } from '@angular/core/testing';

import { SeguroAllanService } from './seguro-allan.service';

describe('SeguroAllanService', () => {
  let service: SeguroAllanService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SeguroAllanService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
