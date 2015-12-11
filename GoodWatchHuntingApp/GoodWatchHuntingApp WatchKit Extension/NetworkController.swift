//
//  NetworkController.swift
//  GoodWatchHuntingApp
//
//  Created by Derek Wheeler on 12/10/15.
//  Copyright © 2015 MyWebGrocer. All rights reserved.
//

import Foundation
import Alamofire

class NetworkController {
    // Singleton Network Controller for use by all application controllers
    static let sharedInstance = NetworkController()
    
    let baseUrl: String = "http://localhost:56357"
    let defaultUser: String = "supersecure420"
    
    func getEvent() {
        //let eventCallUrl: String = "\(baseUrl)/users/\(defaultUser)/events/collection"
    }
    
    func postUserEvent() {
        
    }
    
    func putUserEvent() {
        
    }
    
    func receivedResponse(respone: NSURLResponse) {
        
    }
}