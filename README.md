## _Bank Client with .NET WPF (C#),MongoDB and API Requests_ 
### UI
*The UI part is used using WPF and frameworks such as MaterialDesign.*
- LOGIN & REGISTER Windows
![Login&Register](https://i.imgur.com/XJdNHZl.png)
#### UserMenu:

*These are of the (User Control) type and are displayed in a separate frame from the UserMenu when the menu buttons are pressed.*
- Deposit
- Withdraw
- Accounts
  - View Account
  - Create Account
- Transfer
    - search by username
    - search by IBAN
![UserMenu](https://i.imgur.com/Ship9MI_d.webp?maxwidth=760&fidelity=grand)

## User
#### Cards:
 *(Number, Exp. Date, CVV) - It can be selected when registering a user.*
  - Classic
  - Silver
  - Gold
  - Platinum
  
#### Accounts:
 *Each user can create several bank accounts in different or similar currencies.*
  - RON (DEFAULT):
    - Currency
    - Balance
    - IBAN
 #### User:
 *The user's functionalities for each of his bank accounts.*
 - Deposit
 - Witdraw
 - Transfer *(In case of transfer in another currency, it is converted using an API.)* 
 
 
 #### Database:
 *For the database, I opted for an object-oriented one (MongoDB), all information being stored in a single collection.*
 ```
 {
   "_id":{
      "$oid":"6346d61e2531765c539b8ddf"
   },
   "Username":"mihaita",
   "Password":"cgJvBm6bI+JIjwdnq2PB3XF0leXevEZ2sLliffeu6Tw=",
   "Country":"Romania",
   "First_Name":"Mihaita",
   "Last_Name":"Mihalcea",
   "Cardul":{
      "_t":"Gold",
      "Number":"655672990",
      "CVV":"412",
      "Expiration":"10/27",
      "Tax":{
         "$numberDouble":"0.5"
      }
   },
   "Accounts":[
      {
         "Currency":"RON",
         "Balance":{
            "$numberDouble":"23459.4567"
         },
         "IBAN":"RON89779BNKMM95210148"
      }
   ]
}
```
    
 
    
    



  
