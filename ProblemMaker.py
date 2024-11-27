import random

def write_problem_set():
    easy_problems = [
        ("Create an integer variable A and set it to 5\nIntegerVariableBlock, ABlock, EqualsBlock, FiveBlock"),
        ("Check if variable X equals variable Y\nXBlock, EqualBlock, YBlock"),
        ("Create an integer variable B and set it to 3\nIntegerVariableBlock, BBlock, EqualsBlock, ThreeBlock"),
        ("Check if 4 is greater than 2\nFourBlock, GreaterThanBlock, TwoBlock"),
        ("Create an integer variable C and set it to 7\nIntegerVariableBlock, CBlock, EqualsBlock, SevenBlock"),
        ("Check if 1 is less than 9\nOneBlock, LessThanBlock, NineBlock"),
        ("Create an integer variable X and set it to 6\nIntegerVariableBlock, XBlock, EqualsBlock, SixBlock"),
        ("Check if 8 equals 8\nEightBlock, EqualBlock, EightBlock"),
        ("Create an integer variable Y and set it to 2\nIntegerVariableBlock, YBlock, EqualsBlock, TwoBlock"),
        ("Check if 3 is less than or equal to 5\nThreeBlock, LessThanEqualBlock, FiveBlock")
    ]
    
    medium_problems = [
        ("Create an integer variable A and set it to 3 plus 2\nIntegerVariableBlock, ABlock, EqualsBlock, ThreeBlock, AdditionBlock, TwoBlock"),
        ("Create an integer B and set it to 8 minus 4\nIntegerVariableBlock, BBlock, EqualsBlock, EightBlock, SubtractionBlock, FourBlock"),
        ("Create an integer C and set it to 2 times 3\nIntegerVariableBlock, CBlock, EqualsBlock, TwoBlock, MultiplicationBlock, ThreeBlock"),
        ("Check if 5 plus 2 equals 7\nFiveBlock, AdditionBlock, TwoBlock, EqualBlock, SevenBlock"),
        ("Create an integer X and set it to 9 divided by 3\nIntegerVariableBlock, XBlock, EqualsBlock, NineBlock, DivisionBlock, ThreeBlock"),
        ("Check if 6 minus 2 is greater than 3\nSixBlock, SubtractionBlock, TwoBlock, GreaterThanBlock, ThreeBlock"),
        ("Create an integer Y and set it to 4 times 2\nIntegerVariableBlock, YBlock, EqualsBlock, FourBlock, MultiplicationBlock, TwoBlock"),
        ("Check if 8 divided by 2 equals 4\nEightBlock, DivisionBlock, TwoBlock, EqualBlock, FourBlock")
    ]
    
    hard_problems = [
        ("Create an integer Z and set it to 8 divided by 2 plus 1\nIntegerVariableBlock, ZBlock, EqualsBlock, EightBlock, DivisionBlock, TwoBlock, AdditionBlock, OneBlock"),
        ("Create an integer A and set it to 2 times 3 plus 4\nIntegerVariableBlock, ABlock, EqualsBlock, TwoBlock, MultiplicationBlock, ThreeBlock, AdditionBlock, FourBlock"),
        ("Check if 5 is greater than 2 plus 3 minus 1\nFiveBlock, GreaterThanBlock, TwoBlock, AdditionBlock, ThreeBlock, SubtractionBlock, OneBlock"),
        ("Create an integer X and set it to 9 minus 3 plus 2\nIntegerVariableBlock, XBlock, EqualsBlock, NineBlock, SubtractionBlock, ThreeBlock, AdditionBlock, TwoBlock"),
        ("Create an integer B and set it to 4 times 2 plus 3\nIntegerVariableBlock, BBlock, EqualsBlock, FourBlock, MultiplicationBlock, TwoBlock, AdditionBlock, ThreeBlock"),
        ("Check if 6 divided by 2 plus 1 equals 4\nSixBlock, DivisionBlock, TwoBlock, AdditionBlock, OneBlock, EqualBlock, FourBlock")
    ]
    
    # Select random problems
    selected_easy = random.sample(easy_problems, 3)
    selected_medium = random.sample(medium_problems, 2)
    selected_hard = random.sample(hard_problems, 1)
    
    # Combine all selected problems
    all_problems = selected_easy + selected_medium + selected_hard
    
    # Create possible orderings for problem difficulty
    orderings = [
        [0,0,0,1,1,2],  # EASY EASY EASY MEDIUM MEDIUM HARD
        [1,1,0,0,0,2],  # MEDIUM MEDIUM EASY EASY EASY HARD
        [2,0,0,0,1,1],  # HARD EASY EASY EASY MEDIUM MEDIUM
        [1,0,0,2,0,1],  # MEDIUM EASY EASY HARD EASY MEDIUM
        [0,1,1,0,2,0],  # EASY MEDIUM MEDIUM EASY HARD EASY
        [0,2,1,0,1,0]   # EASY HARD MEDIUM EASY MEDIUM EASY
    ]
    
    # Select random ordering
    chosen_order = random.choice(orderings)
    
    # Create final ordered problem list
    final_problems = []
    easy_count = 0
    medium_count = 0
    hard_count = 0
    
    for difficulty in chosen_order:
        if difficulty == 0:
            final_problems.append(selected_easy[easy_count])
            easy_count += 1
        elif difficulty == 1:
            final_problems.append(selected_medium[medium_count])
            medium_count += 1
        else:
            final_problems.append(selected_hard[hard_count])
            hard_count += 1
    
    # Write to file
    with open('problemset.txt', 'w') as f:
        f.write("6\n")  # Number of problems
        for problem in final_problems:
            f.write(f"{problem}\n")

if __name__ == "__main__":
    write_problem_set()