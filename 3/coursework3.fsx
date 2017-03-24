(*

  ITT8060 -- Advanced Programming 2016
  Department of Computer Science
  Tallinn University of Technology
  ------------------------------------

  Coursework 3: User defined types

  ------------------------------------
  Name:
  TUT Student ID: eselsh@ttu.ee
  ------------------------------------


  Answer the questions below.  You answers to questions 1--7 should be
  correct F# code written after the question. This file is an F#
  script file, it should be possible to load the whole file at
  once. If you can't then you have introduced a syntax error
  somewhere.

  This coursework will be graded. It has to be submitted to the TUT
  git system using the instructions on the course web page by October 9, 2015.
*)

// 1. Consider expression trees of type ExprTree declared in the lecture.
// Extend the type with if-then-else expression of the form:
// if b then e1 else e2
// where b is a boolean expression and e1 and e2 are expressions.
// An example expression could be:
// if a+3 > b+c && a>0 then c+d else e
type ExprTree = | Const  of int
                | Ident of string
                | Minus  of ExprTree
                | Sum    of ExprTree * ExprTree
                | Diff   of ExprTree * ExprTree
                | Prod   of ExprTree * ExprTree
                | Let    of string * ExprTree * ExprTree
                | Cond  of bool * ExprTree * ExprTree



// 2. Extend the function eval defined in the lecture to support the
// if-then-else expressions defined in Q1.
let rec eval t env =
    match t with
    | Const n        -> n
    | Ident s        -> Map.find s env
    | Minus t        -> - (eval t env)
    | Sum (t1,t2)    -> eval t1 env + eval t2 env
    | Diff (t1,t2)   -> eval t1 env - eval t2 env
    | Prod (t1,t2)   -> eval t1 env * eval t2 env
    | Let (s,t1,t2)  -> let v1 = eval t1 env
                        let env1 = Map.add s v1 env
                        eval t2 env1
    | Cond (b,e1,e2) -> if b then eval e1 env else eval e2 env
// 3-4: Given the type definition:
type BList =
  | BEmpty
  | Snoc of BList * int
//
// 3. Make the function filterB: (prop: int -> bool) BList -> BList that will return a list for the elements of which
// the function prop returns true.
                                    
let rec filterB (prop: int -> bool) BList =
                    match BList with
                    | BEmpty -> BEmpty
                    | Snoc(head, tail) -> 
                                    let tempB = filterB prop head                                    
                                    if prop tail
                                    then Snoc(tempB, tail) 
                                    else tempB

// 4. Make the function mapB: (trans: int -> int) BList -> BList that will return a list where the function trans has
// been applied to each element.


let rec mapB (trans: int -> int) BList =
                    match BList with
                    | BEmpty -> BEmpty
                    | Snoc(head,tail) -> let resulk = mapB trans head
                                         Snoc(resulk, trans tail)

// 5-7. Given the type definition
type Tree =
  | Nil
  | Branch2 of Tree * int * Tree
  | Branch3 of Tree * int * Tree * int * Tree
//
// 5. Define the value exampleTree : Tree that represents the following
//    tree:
//
//        2
//       / \
//      *  3 5
//        / | \
//       *  *  *

let exampleTree = Branch2(Nil, 2, Branch3(Nil, 3, Nil, 5, Nil))

// 6. Define a function sumTree : Tree -> int that computes the sum of
//    all labels in the given tree.

let rec sumTree: Tree -> int = function
    | Nil -> 0
    | Branch2(t1,x,t2) -> x + (sumTree t1) + (sumTree t2)
    | Branch3(t1,x,t2,y,t3) -> x + y + (sumTree t1) + (sumTree t2) + (sumTree t3)


// 7. Define a function productTree : Tree -> int that computes the
//    product of all labels in the given tree. If this function
//    encounters a label 0, it shall not look at any further labels, but
//    return 0 right away.


let rec productTree: Tree -> int = function
    | Nil -> 1
    | Branch2(t1,0,t2) -> 0
    | Branch2(t1,x,t2) -> x * (productTree t1) * (productTree t2)
    | Branch3(t1,0,t2,0,t3) -> 0
    | Branch3(t1,x,t2,y,t3) -> x * y * (productTree t1) * (productTree t2) * (productTree t3)

// ** Bonus questions **

// 8. Extend the ExprTree type with a pattern match expression
// match p with [p1, ex1; p2,ex2 ...]

// 9. Extend the eval function to support match expressions.
