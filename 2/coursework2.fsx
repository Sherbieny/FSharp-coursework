(*

  ITT8060 -- Advanced Programming 2016
  Department of Computer Science
  Tallinn University of Technology
  ------------------------------------

  Coursework 2: Operations on lists, recursion

  ------------------------------------
  Name:
  TUT Student ID: eselsh@ttu.ee
  ------------------------------------


  Answer the questions below.  You answers to all questions should be
  correct F# code written after the question. This file is an F#
  script file, it should be possible to load the whole file at
  once. If you can't then you have introduced a syntax error
  somewhere.

  This coursework will be graded. It has to be submitted to the TUT
  git system using the instructions on the course web page by September 30, 2016.
*)

// 1. Make a value sl containing empty list of type string list.
let s1 = [""]

// 2. Make a function shuffle: int list -> int list that rearranges the elements of the argument list
// in such a way that the first value goes to first, last to second,
// second to third, last but one to fourth etc.
// E.g.
// shuffle [] -> []
// shuffle [1;2] -> [1;2]
// shuffle [1..4] -> [1;4;2;3]

let rec shuffle (list: int list) : (int list) =       
    match list with
    | [] -> []
    | [x] -> [x]
    | head::tail -> head :: shuffle (List.rev tail)
   // | [x] -> [x]
   // | head::tail -> head :: List.last tail :: shuffle (List.foldBack2 tail)

shuffle [1..6]
// 3. Make a function segments: int list -> int list list that splits the list passed
// as an argument into list of lists of nondecreasing segments.
// The segments need to be of maximal possible length (the number of segments
// needs to be minimal)
// E.g.
// segments [] ->  []
// segments [1] -> [[1]]
// segments [3;4;5;5;1;2;3] -> [[3;4;5;5];[1;2;3]]

let rec segments (list: int list) : (int list list) = 
    match list with
    | [] -> []
    | [x] -> [[x]]
    | head::tail ->
        if head > tail.Head then
            [head] :: segments tail
        else
           (List.append [head] [tail.Head]) :: segments tail.Tail
            
segments [3;4;5;5;1;2;3]

//NOTE: This is the best I could do with this one, I can't understand "fold" in case this is to be solved using it
        

    

// 4. Make a function sumSublists : int list list -> int list that will compute the sums of sublists in a list of list of ints.
// Hint: use the function List.fold to compute the sums of lists of ints.


let sumList list: int = List.sum list

let sumSublists subLists = List.map (fun (x: list<int>) -> List.sum x) subLists



// 5. Write a function filterSegments : (int list -> bool) -> int list list -> int list list that will filter out lists of ints
// based on some filter function. Write a filter function for even sum, odd sum, even number of elements, odd number of elements.



// 5. Write a function filterSegments : (int list -> bool) -> int list list -> int list list that will filter out lists of ints
// based on some filter function. Write a filter function for even sum, odd sum, even number of elements, odd number of elements.
(*
let evenSum list = if List.sum(list) % 2 = 0 then
                        true
                    else
                        false        
let oddSum list =  if List.sum(list) % 2 = 1 then
                        true
                    else
                        false        
let evenNE list =  if List.length(list) % 2 = 0 then
                        true
                    else
                        false
let oddNE list =  if List.length(list) % 2 = 1 then
                        true
                    else
                        false
let lists = [[1;3];[2;2];[3;6]]
let rec filterSegmentsTemp (funk: int list) (lists: int list list) = 
                                            match lists with
                                                | [] -> []
                                                | head::tail ->
                                                    match head with
                                                    | [] -> []
                                                    | head::tail when funk head = true -> filterSegmentsTemp (funk (head))
                                                    | _::tail -> filterSegmentsTemp (funk (tail))
                                                     

 *)                                                   
// I will find a solution to these problems                                              
(*                                     
                 
                             let f p x =
                                match x with
                                | x when x < p -> -1
                                | x when x = p ->  0
                                | _ -> 1


                                       lists |> List.map(fun x -> 
                                                if (funk x = true) 
                                                then 
                                                    return filterSegmentsTemp x.Head)
                                                else
                                                   return filterSegmentsTemp x.Tail
                                                end
                                                    )
*)                                
                                                    
                                                           
