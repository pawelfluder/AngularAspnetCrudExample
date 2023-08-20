import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { editEmployeeResolver } from './edit-employee.resolver';

describe('editEmployeeResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => editEmployeeResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
