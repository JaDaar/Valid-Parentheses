using System;
using System.Collections;
/*
https://leetcode.com/problems/valid-parentheses/
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
 

Example 1:

Input: s = "()"
Output: true
Example 2:

Input: s = "()[]{}"
Output: true
Example 3:

Input: s = "(]"
Output: false
Example 4:

Input: s = "([)]"
Output: false
Example 5:

Input: s = "{[]}"
Output: true
 

Constraints:

1 <= s.length <= 104
s consists of parentheses only '()[]{}'

*/


class Program {
  public static void Main (string[] args) {
    //var parse="()[]([])";
    //var parse="([])";
    //var parse="([)]";
    //var parse="(((";
    //var parse="(){}}{[()]";
    var parse="[[[]";
    Console.WriteLine($"The String is {IsValid2(parse)}");
  }


  public static bool IsValid2(string s){
      Stack items=new Stack();
      char[] arr=arr = s.ToCharArray();
      for( int i=0;i<arr.Length;i++)  {
          if(arr[i]=='{' || arr[i]=='[' || arr[i]=='('){
              items.Push(arr[i]);
          }else if(arr[i]=='}' && items.Count>0 && items.Peek().ToString() == "{"){
              items.Pop();
              Console.WriteLine("Popping a Bracket");
          }else if(arr[i]==']' && items.Count>0 && items.Peek().ToString() == "["){
              items.Pop();
              Console.WriteLine("Popping a Square Bracket");
          }else if(arr[i]==')' && items.Count>0 && items.Peek().ToString() == "("){
              items.Pop();
              Console.WriteLine("Popping a Parenthesis");
          }else
            return false;
      }
      return (items.Count>0)?false:true;
  }
  public static bool IsValid(string s) {

     var str=s;
     Stack items=new Stack();
     char[] arr;
     var parent=0;
     var brack=0;
     var sbrack=0;

    // if the length isn't even it must have a missing pair
     if(str.Length %2>0){
         Console.WriteLine("Invalid-1");
         return false;
     }

     if(!str.Contains("()") && !str.Contains("{}") && !str.Contains("[]")){
         Console.WriteLine("Invalid-2");
         return false;
     }
        

     arr = str.ToCharArray();
     for(int i=0;i<arr.Length;i++){
         if(arr[i]=='(' && parent>=0){
             parent+=1;
         }else if(arr[i]==')' && parent>=0){
             parent-=1;
         }
         if(arr[i]=='[' && sbrack>=0){
             sbrack+=1;
         }else if(arr[i]==']' && sbrack>=0){
             sbrack-=1;
         }    
         if(arr[i]=='{' && brack>=0){
             brack+=1;
         }else if(arr[i]=='}' && brack>=0){
             brack-=1;
         }                
     }
     
     Console.WriteLine($"Parenthesis {parent}\nSquare Brackets {sbrack}\nBraces {brack}");
        if (parent >= 0 && sbrack >= 0 && brack >= 0)
        {
            return true;
        }
        else if(parent<0 || sbrack<0 || brack<0)
        {
            return false;
        }
        return false;

  }
}