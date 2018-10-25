export class Post {
    public id = '';
    public title = '';
    public description = '';
    public author = '';
    public createdDate: Date;

    public deserialize(input: any) {
        this.id = input.id;
        this.title = input.title;
        this.description = input.description;
        this.author = input.author;
        this.createdDate = input.createdDate;

        return this;
    }
}
