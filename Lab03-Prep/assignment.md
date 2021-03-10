OOD 2020L

# Structure of the data

The example XML file contains a list of products available at a general store
and a list of additions used in these products.

The document root is goods, containing an arbitrary amount of food and article
elements, given in any order (food and article elements can be mixed with each
other), *followed* by *exactly one* additions element.

Each food element contains the following attributes (all required):
 - name attribute containing the name of the product (any string),
 - calories attribute containing a number greater than 5 (not necessarily an
   integer) [kilo]calories provided the product,
 - product code in ERP systemA-, in the following format: two uppercase letters,
   hyphen, sequence of at least 1 digit, hyphen, one lowercase letter (example:
   AB-123-c),
and zero or more addition elements, each addition element containing an integer
id referring to an addition defined later in the document. Each addition id must
be unique within a food element. After addition elements there is exactly one
origin element describing the origin of the product (any string).

Each article element contains the following attributes (all required):
 - name attribute containing the name of the product (any string),
 - type attribute containing one of the following: cleaner, cosmetic, tool,
 - product code in ERP system, in the following format: two uppercase letters,
   hyphen, sequence of at least 1 digit, hyphen, one lowercase letter,
and zero or more addition elements, each addition element containing an integer
id referring to an addition defined later in the document. Each addition id must
be unique within an article element.

The last element of goods -- additions has no attributes. It contains a list of
all possible additions -- addition elements.
Each addition element in this list has the following attributes:
 - id -- an integer, required, must be unique across the entire file,
 - name -- a string, required,
 - code -- substance code, in the format: uppercase letter E followed by exactly
   three digits. This attribute is *optional*.

Proper references must be enforced: addition elements *must* refer to the id
attribute of an existing addition from the list at the end of the document.

# Notes on sending the solution

You have to send a complete xml, xsd and C# solution (with all project
files). Please remove any binary files (folders bin, obj, .vs) before sending
the solution.

# Detailed requirements

- (0.5 pts) Define XSD that will enforce the structure of the document. No keys
  and reference enforcement at this point. Modify XML so that elements are
  connected with XSD definition.
- (0.5 pts) Avoid defining the common part of the types twice.
- (0.5 pts) Write a program in C# which will read the XML given as a command
  line argument and print to stdout: product in the format: (type Food or
  Article): (name) (list of addition *names*).
- (0.5 pts) The solution is divided into separate projects: class library and
  main project -- console app.
- (0.5 pts) Classes are automatically generated from XSD during compilation
  process.
- (0.5 pts) If the provided XML does not conform to XSD, the program prints an
  error message and exits.
- (1 point) Enforce uniqueness of ids and correctness of references.
- (1 point) Enforce unique additions in each food/article.
