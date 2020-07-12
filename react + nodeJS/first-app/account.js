class Account{
    constructor(balance, limit, name){
        this.balance=balance;
        this.limit=limit;
        this.name=name;
    }
    getInfo()    {
        return {
            Name:  this.name,
            Balance: this.balance,
            AccountDailyLimit: this.limit,
        }
    }
}

module.exports = Account;