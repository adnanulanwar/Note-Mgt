export class User {
    public UserID: number;
    public Name: string;
    public Email: string;
    public Password: string;
    public DateOfBirth: Date;
    public ErrorMessage: string;
    public Key: string;
    public constructor() {
        this.UserID = 0;
        this.Name = "";
        this.Email = "";
        this.Password = "";
        this.DateOfBirth = new Date();
        this.ErrorMessage = "";
        this.Key = "";
    }
}