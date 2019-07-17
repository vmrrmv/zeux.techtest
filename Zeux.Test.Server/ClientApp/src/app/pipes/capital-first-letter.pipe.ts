import { Pipe, PipeTransform } from '@angular/core';
 
@Pipe({
    name: 'capitalfirstletter'
})
export class CapitalFirstLetterPipe implements PipeTransform {
  transform(value: string, args?: any): string {
    if(value)
      return value.charAt(0).toUpperCase()+ value.slice(1);
    else return value 
  }
}