# Answers to Questions from questions.md

# Answer 1
Subject:  Bad design  

Hi Marissa,  
  
Thank you for your feedback, I understand that how the new dashboard design has caused some inconvenience for you.

As we are constantly working on making our platform user-friendly and efficient, I will take your feedback and discuss it with our product team.

If clearing and deleting indexes is a constant operation, would you be interested to know more about how you could achieve these operations using the API clients available?  

In the meantime, if there’s anything else you need assistance with, please feel free to reach out.
   
Thanks,  
Ollie  


# Answer 2
Subject: URGENT ISSUE WITH PRODUCTION!!!! 

Hi Carrie,

I am sorry to hear this has happened in your production instance this morning.

It sounds like the extra metadata that is not used for search is causing this issue and our best practices recommend you not to index this data.

To give us time to work on an ideal solution, would you be happy to consider the following workaround - before sending the record to Algolia, I propose extractibg the metadata that is not used for search and storing it locally? For example, generating a .txt file for each feedback that stores the extra metadata.

This approach will instantly reduce the record size sent to Algolia and should allow users to be able to post their feedback once again. 

If the proposed workaround is not suitable, I am available this morning to connect to further investigate this and resolve this issue swiftly.

Kind Regards,
Ollie

# Answer 3
Subject: Error on website  

Hi Marc,

I hope you are well!

Unfortuantely from the screenshot alone, I am unable to confirm the root cause of this issue, in order to help reoslve this could you check the following:

- If 'searchkit' is a module that you're trying to use, has it been imported correctly?
- If 'searchkit' is a variable, has it been defined before it is used? 
- If 'searchkit' is variable, function, or object, has it been spelled correctly where it is used?

If these checks do not resolve your issue or if you would like assistance, please respond with further context on issue such as when you first started seeing this as well as any relevant files from your website e.g. index.js.

Kind Regards,
Ollie







