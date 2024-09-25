//CAB301 - Assignment 2 
//Tool ADT implementation


using System;
using System.Data;
using System.Text;


//Invariants: Name=!null and Number >=1

partial class Tool : ITool
{
    private string name;
    private int number;
    private string[] borrowerList;

    //constructor 
    public Tool(string name, int number = 0)
    {
        if (name == null)
            throw new ArgumentNullException("Name is null");
        else
        { 
            this.name = name;
            this.number = number;
            borrowerList = new string[0];
        }
    }

    //get the name of this tool
    public string Name 
    {
        get { return name; }   // get method
    }

    //get the number of this tool currently available in the tool library
    public int Number 
    {
        get { return number; }   // get method
    }

    //check if a person is in the borrower list of this tool (is holding this tool)
    //Pre-condition: nil
    //Post-condition: return true if the person is in the borrower list; return false otherwise. The information about this tool remains unchanged.
    public bool IsInBorrowerList(string personName)
    {
        for (int i = 0; i < borrowerList.Length; i++)
        {
            if (borrowerList[i] == personName)
            {
                return true;
            }
        }
        return false; 
    }


    //add a person to the borrower list
    //Pre-condition: the borrower is not in the borrower list and Number > 0
    //Post-condition: the borrower is added to the borrower list and new Number = old Number - 1
    public bool AddBorrower(string personName)
    {
        //Satisfy Pre Condition.
        if ((!IsInBorrowerList(personName)) && Number > 0)
        {
            
            //Create a new resizeable array.
            string[] newBorrowerList = new string[borrowerList.Length + 1];

            //Copy old members to new array.
            for (int i = 0;i < borrowerList.Length; i ++)
            {
                newBorrowerList[i] = borrowerList[i];
            }
            //Add new member to new array.
            newBorrowerList[newBorrowerList.Length - 1] = personName;

            //Update borrower List with new array.
            borrowerList = newBorrowerList;
            //Update the Number of tools
            number--;
            return true;
        }
        return false;
    }


    //remove a borrower from the borrower list
    //Pre-condition: the borrower is in the borrower list
    //Post-condition: the borrower is removed from the borrower list and new Number = old Number + 1
    public bool RemoveBorrower(string personName)
    {
        //Satisfy PreCondition
        if (IsInBorrowerList(personName))
        {
            //Create a new resizeable array.
            string[] newBorrowerList = new string[borrowerList.Length - 1];

            //Copy old members to new array except for personName.
            for (int i = 0, j = 0; i < borrowerList.Length; i++)
            {
                if (borrowerList[i] != personName)
                {
                    newBorrowerList[j] = borrowerList[i];
                    j++;
                }
            }
            //Update borrower List with new array.
            borrowerList = newBorrowerList;

            //Update the number of tools
            number++;
            return true;
        }
        return false;
    }


    //Compare this tool's name to another tool's name 
    //Pre-condition: anotherTool != null
    //Post-condition:  return -1, if this tool's name is less than another tool's name by alphabetical order
    //                 return 0, if this tool's name equals to another tool's name by alphabetical order
    //                 return +1, if this tool's name is greater than another tool's name by alphabetical order

    public int CompareTo(ITool? anotherTool)
    {
        //Satisfy Pre-Condition
        if (anotherTool == null)
        {
            throw new ArgumentNullException("anotherTool doesn't exist");
        }

        if (this.name.CompareTo(anotherTool.Name) < 0)
        {
            return -1;
        }
        if (this.name.CompareTo(anotherTool.Name) == 0)
        {
            return 0; 
        }
        return 1;
        
    }


    //Return a string containing the name and the number of this tool currently in the tool library 
    //Pre-condition: nil
    //Post-condition: A string containing the name and number of this tool is returned

    public override string ToString()
    {
        return Name + "," + Number;
    }
}
