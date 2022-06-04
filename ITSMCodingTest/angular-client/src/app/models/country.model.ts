export class Country {
    Name: string = "";
    Alpha3Code: string = "";
    Alpha2Code: string = "";

    constructor(name: string, alpha2Code: string, alpha3Code: string){
        this.Name = name;
        this.Alpha2Code = alpha2Code;
        this.Alpha3Code = alpha3Code;
    }
}
