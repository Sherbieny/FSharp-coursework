(*

  ITT8060 -- Advanced Programming 2016
  Department of Computer Science
  Tallinn University of Technology
  ------------------------------------

  Coursework 4: Higher order functions, option, list

  ------------------------------------
  Name:
  Student ID: eselsh@ttu.ee
  ------------------------------------


  Answer the questions below. You answers to the questions should be
  correct F# code written after the question. This file is an F# script
  file; it should be possible to load the whole file at once. If you
  can't, then you have introduced a syntax error somewhere.

  This coursework will be graded.

  Commit and push your solution to the repository as file
  coursework4.fsx in directory coursework4.

  The deadline for completing the above procedure is Friday,
  October 21, 2016.

  We will consider the submission to be the latest version of the
  appropriate files in the appropriate directory before the deadline
  of a particular coursework.

*)

// 1. Write a function by pattern matching
// 
//   flattenOption : option<option<'a>> -> option<'a>
//
//   which squashes two layers of possible successes or failures into 1
//   E.g. Some Some 1 -> Some 1

let flattenOption a = 
    match a with
    | None -> None
    | Some a -> a

 
//flattenOption (Some (Some 1))

// 2. Can flattenOption by implemented using bind? If so, do it!
let flatten a = 
    if a = None then None else Some 1

let flattenbind a =
    a
    |> Option.bind flatten

//flattenbind (Some (Some 1))

// 3. Write a function
//
//    idealist : list<option<'a>> -> list<'a>
//
//    which collects a list of possible successes or failures into a
//    list containing only the successes. Pay close attention to the type.
let rec idealist list = 
        match list with
        | [] -> []
        | head::tail -> 
            match head with            
            | None -> idealist tail
            | Some a -> Option.get head :: idealist tail

//idealist [Some 1; None; Some 5; None]    
    
// 4. Write a function
//
//    conservative : list<option<'a>> -> option<list<'a>>
//
//    that takes a list of possible successes or failures and returns
//    a list of successes if everything succeeded or returns failure
//    if 1 or more elements of the list was a failure. Again, pay
//    close attention to the type.


let conservative list = 
                if (list |> List.exists(fun elem -> 
                    Option.isNone elem)) then [None] //I could not return different types
                else
                    list
                    
        
conservative [Some 1; Some 2; Some 5; Some 0]  
conservative [Some 1; Some 2; Some 5; None]  

// 5. Write a function
//
//    chars : list<string> -> list<char>
//
//    This function should use List.collect (bind) and have the
//    following behaviour:
//    ["hello";"world"] -> ['h';'e';'l';'l';'o';'w';'o';'r';'l';'d']

let chars (stringList : string list) = 
                            stringList |> List.collect(fun (elem : string) -> 
                                [for c in elem -> c])

//chars ["hello";"world"]

// 6. Write a function
//
//    iprint : list<int> -> string
//
//    This function should use List.foldBack and have the following behaviour:
//    [1 .. 5] |-> "1,2,3,4,5,"

let iprint (intList : int list) = 
                        intList 
                        |> List.foldBack(fun elem acc -> elem::acc) []
                        |> List.map( fun s -> s.ToString()) |> String.concat ","
                                              

                
//iprint [1 .. 5]
