export class Note {
    public ID: number;
    public NoteMessage: string;
    public NoteType: number;
    public UserID: number;
    public NoteCreateTime: Date;
    public ErrorMessage: string;
    public ReminderTime: Date;
    public constructor() {
        this.ID = 0;
        this.NoteMessage = "";
        this.NoteType = 0;
        this.UserID = 0;
        this.NoteCreateTime = new Date();
        this.ReminderTime = new Date();
        this.ErrorMessage = "";
    }
}