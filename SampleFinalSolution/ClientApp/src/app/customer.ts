export class Customer {
  constructor(
    public id: string,
    public firstname: string | null,
    public gender: string | null,
    public lastname: string | null,
    public email: string,
    public country_Code: string | null,
    public balance: string | null,
    public phone_Number: string | null
  ) { }
}
