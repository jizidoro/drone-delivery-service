Deployed Program Access:
https://drone-delivery-3c0058a7004d.herokuapp.com/swagger/index.html

Source Code Access:
https://github.com/yakkumo/drone-delivery-service

How to Use
Access the link where the project is deployed and upload a valid file using the provided upload field. After processing, you will receive a link to download the response file.

Assumptions:

    Time and distance to each drop-off location are not considered.
    Package sizes are not a factor; only their weight matters.
    The refueling and restocking cost for each drone is a fixed constant across all drones.
    A drone squad can consist of up to 100 drones, with no upper limit on the number of deliveries.

Algorithm:
The problem is addressed in a structured three-step sequence:

    Input File Processing (ProcessFile.Execute): This step involves parsing the provided file, reading each line, and extracting drone and location data.
        The data is separated based on specific patterns.
        Any inconsistencies or erroneous data lead to an early exit with an empty result to indicate the invalid input format.
        Valid drone and location data are stored in lists for further processing.

    Drone Loading Optimization (GetMinimalCombination.Execute): Here, we determine the best way to load drones efficiently, minimizing the number of trips each drone has to make.
        A Dynamic Programming approach is used, leveraging the CalculateDPTable.Execute function to create a table indicating possible weight combinations for the available package weights.
        The ExtractCombination.Execute function uses this table to identify an optimal set of packages for a drone to carry in a single trip, ensuring the drone carries as close to its capacity as possible.
        Packages are then assigned to drones in a way that the drone with the highest carrying capacity is prioritized. Once a package set is assigned, those packages are removed from the available list.
        This process continues until all packages have been assigned.

    Output File Generation (GenerateOutput.Execute & GenerateErrorOutput.Execute):
        A result is generated detailing the trips each drone will take, formatted as requested.
        If there was an error in the input data processing, the GenerateErrorOutput.Execute method provides a message indicating an invalid input.

Key Points on Component Functions:

    ProcessFile.Execute: Responsible for parsing the provided file and segregating data into drones and locations.

    CalculateDPTable.Execute: Uses dynamic programming to identify possible weight combinations up to the maximum drone capacity.

    ExtractCombination.Execute: Determines the optimal package set for a drone to carry, utilizing the previously calculated DP table.

    GetMinimalCombination.Execute: Orchestrates the assignment of packages to drones based on their capacities.

    GenerateOutput.Execute: Transforms the result into the desired format, indicating each drone's trips and the packages they carry.

    GenerateErrorOutput.Execute: Returns an error message when the input file contains inconsistencies or invalid data.    


Walk Through Solution:
The foundation of our development was based on creating a mock test, simulating our input file to streamline our workflow. The initial step involved devising an input file parser tailored for our specific data structure. This ensured efficient extraction and transformation of the data into relevant objects. These objects, formed through careful modeling, were pivotal in problem-solving and seamless inter-class communication.

Given that the core issue revolved around a classic optimization problem, we employed a dynamic programming (DP) table to explore various loading possibilities. Absent explicit directives regarding drone usage, our algorithm leaned towards deploying drones with higher weight capacities. However, for final payloads, we integrated a heuristic to utilize drones with the least capacity, optimizing resource allocation.

Upon accumulating the requisite data, we designed the output processor. The entire solution was then deployed using Heroku for easy access and visualization.

Technical Dependencies and Libraries:
The project was developed using .NET 6 with Visual Studio 2022. Testing was comprehensively executed using xUnit. For more user-friendly interactions and an intuitive interface, we incorporated Swagger in the application, allowing easy API endpoint testing and documentation.

