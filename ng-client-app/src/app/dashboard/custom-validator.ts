import { inject } from '@angular/core';
import { PersonService } from '../services/person.service';
import { AbstractControl } from '@angular/forms';
import { map, of } from 'rxjs';
export const personService = inject(PersonService);

export function isExist(control: AbstractControl) {
  return personService.isNationalNoExist(control.value).pipe(
    map((res) => {
      if (res) {
        console.log(res);
        return of({ notUnique: true });
      } else {
        return of(null);
      }
    })
  );
}
