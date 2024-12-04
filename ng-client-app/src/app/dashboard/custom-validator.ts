import { PersonService } from '../services/person.service';
import { AbstractControl } from '@angular/forms';
import { map, Observable } from 'rxjs';

export function isExist(personService: PersonService) {
  return (control: AbstractControl): Observable<any> => {
    return personService
      .isNationalNoExist(control.value)
      .pipe(map((res) => (res ? { notUnique: true } : null)));
  };
}
